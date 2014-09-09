module Tests

open Xunit
open FsUnit
open GameOfLifeF

[<Fact>]
let ``Any live cell with fewer than two live neighbours dies, as if caused by under-population``() =
    set [
        (0, 1); (1, 1)
    ]
    |> nextGeneration
    |> should not' (contain (1, 1))

[<Fact>]
let ``Any live cell with two live neighbours lives on to the next generation``() =
    set [
        (0, 1); (1, 1); (2, 1)
    ]
    |> nextGeneration
    |> should contain (1, 1)

[<Fact>]
let ``Any live cell with three live neighbours lives on to the next generation``() =
    set [
        (0, 1); (1, 1); (2, 1);
                (1, 2)
    ]
    |> nextGeneration
    |> should contain (1, 1)

[<Fact>]
let ``Any live cell with more than three live neighbours dies, as if by overcrowding``() =
    set [
                (1, 0);
        (0, 1); (1, 1); (2, 1);
                (1, 2)
    ]
    |> nextGeneration
    |> should not' (contain (1, 1))

[<Fact>]
let ``Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction``() =
    set [
                (1, 0);
        (0, 1);         (2, 1);
    ]
    |> nextGeneration
    |> should contain (1, 1)