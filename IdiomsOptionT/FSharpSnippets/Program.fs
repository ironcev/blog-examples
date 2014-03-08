let keepIfPositive (a : int) = if a > 0 then Some(a) else None

let result = keepIfPositive(100)
if result.IsSome then
    let c = 1 + result.Value
    printf "%d" c

