# FixedPoint-Sharp

This is a Hourai Teahosue specific fork of [RomanZhu's
FixedPoint-Sharp](https://github.com/RomanZhu/FixedPoint-Sharp) library aimed at
use specifically in games developed in Unity 2018.3+.

## Features
- `fp` is a Q48.16 precision fixed point value type and a drop-in replacement for
  floats/doubles.
- `fp2`, `fp3`, `fp4` for 2D/3D/4D vector math.
- Effective range: -2^15 to +2^15 with 16 bits of fractional precision.
- Precision chosen for maximum performance.
- Random generator for fp, int, bool, and vector types
- LUT-based trigonometry with lerping
- Supports cross-platform deterministic non-integer calculations.
- Works with C#'s `checked`/`unchecked` blocks for overflow protection.

## Why fixed point?
Floating point types are ubiquitious and universally useful. Almost every modern
CPU outside of embedded devices have a deadicated FPU (floating-point unit), and
compilers recognize and optimize floating point operations very well. However,
due to these operations and potentially standards non-compliant FPU
implemenations, not all floating point calculations are deterministic across all
platforms. Enter fixed point computations. Fixed point calculations turn
non-integer compuations into basic integer calculations, which are always
guarenteed to be determinsitic across all platforms: 1 + 3 is always 4.

This level of determinism has many use cases; however, the focus of
FixedMath-Sharp is to enable deterministic simulations in games to allow for
bandwidth efficient netcode. Netplay paradigms like deterministic lockstep and
rollback are strictly reliant on having a 100% deterministic gameplay simulation.
Non-deterministic compuations may result in butterfly effects desyncing the
participating players.

## Why Q48.16?
Practically, Q48.16 represents a practical performance to precision tradeoff. As
described above, when using fixed point, the aim is often determinism over
everything else. Q48.16 allows storing a reasonably accurate value in common
64-bit integers without a signifgant amount of extra computation to prevent
overflows, which makes it signifigantly faster than a Q31.32 implementation at
the cost of precision.

## Why not FixedMath.NET?
FixedMath.NET uses a Q31.32 implemenation, which, as decribed above, is less
CPU-cycle efficient but can be more precise. As the target use case of this
library is foxused on game development, FixedPoint-Sharp focuses more on
perfromance than precision. Applications that need signifigantly more
precision will likely need to use FixedMath.NET

## Installation

Installation of this package requires Unity 2018.3 or higher.

Under `Packages/manifest.json`, add the following lines, then open the Unity
Editor. Note: this will add a scoped registry to your project.

```json
{
  "dependencies": {
    "com.facepunch.fp": "1.0.0"
  },
  "scopedRegistries": [
    {
      "name": "Hourai Teahouse",
      "url": "https://upm.houraiteahouse.net",
      "scopes": ["com.houraiteahouse"]
    }
  ]
}
```

## License
[MIT](./LICENSE)

## Related Libraries
- [Backroll](https://github.com/HouraiTeahouse/Backroll)
