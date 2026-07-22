# Gilded Rose (C# / xUnit)

Each day, `GildedRose` asks `ItemUpdaterFactory` for the right updater, then that updater applies the shared template: **update quality → decrease sell-in → apply expired rules if needed**.

Inventory quality system for the Gilded Rose inn. This work had two parts:

1. **Refactor** — replace the legacy nested `UpdateQuality` logic with a clear strategy-based design  
2. **New feature** — add **Conjured items**, which were **not** supported in the original logic

## New feature: Conjured items

The inn signed a new supplier for conjured goods (for example, *Conjured Mana Cake*). The original system had no real rule for them — they were treated like ordinary stock.

Added Conjured as a first-class item category:

- Quality degrades **twice as fast** as ordinary goods  
- After the sell-by date, they still degrade twice as fast as normal items would in that situation  
- Quality still never goes below zero  

See [Business rules](docs/BUSINESS_RULES.md) for the product-facing description.

## What's changed

| Area | Before | After |
|------|--------|--------|
| `UpdateQuality` | Large nested `if`/`else` chain | Thin loop that delegates to per-item updaters |
| Item rules | Mixed in one method | One updater class per item category |
| **Conjured items** | **Not a real feature** (behaved like ordinary goods) | **New feature** — dedicated rules, 2× degradation |
| `Item` class | Untouched | Still untouched |


## Project layout

```
├── GildedRose/
│   ├── GildedRose.cs          # Orchestrates daily update
│   ├── Program.cs             # Demo CLI / approval harness
│   ├── Base/
│   │   └── ItemUpdaterBase.cs 
│   ├── Models/
│   │   └── Item.cs            # Name, SellIn, Quality
│   ├── Factories/
│   │   └── ItemUpdaterFactory.cs
│   └── Updaters/
│       ├── ItemUpdater.cs     # Shared update algorithm (abstract)
│       ├── NormalItemUpdater.cs
│       ├── AgedBrieUpdater.cs
│       ├── BackstagePassUpdater.cs
│       ├── SulfurasUpdater.cs
│       └── ConjuredItemUpdater.cs
├── GildedRoseTests/           # Unit + approval tests
├── docs/
│   ├── ARCHITECTURE.md        # Design, diagrams, flow
│   └── BUSINESS_RULES.md      # Inventory rules
└── README.md
```

## Quick start

### Build

```cmd
dotnet build GildedRose.sln -c Debug
```

### Run the demo (N days)

```cmd
dotnet run --project GildedRose -- 10
```

Or after building:

```cmd
GildedRose\bin\Debug\net10.0\GildedRose.exe 10
```

### Run tests

```cmd
dotnet test
```

## Documentation

- [Architecture & logic](docs/ARCHITECTURE.md) — design, class diagram, update flow
- [Business rules](docs/BUSINESS_RULES.md) — How inventory value changes (non-technical)