module GameOfLifeF

let isAlive grid cell = Set.contains cell grid

let isDead grid cell = isAlive grid cell |> not

let neighbours (x, y) =
    set [
        (x-1, y-1);   (x-1, y);   (x-1, y+1);
        (x, y-1);                 (x, y+1);
        (x+1, y-1);   (x+1, y);   (x+1, y+1);
    ]

let aliveNeighbours grid cell =
    neighbours cell
    |> Set.filter (isAlive grid)
    |> Set.count

let deadNeighbours grid cell =
    neighbours cell
    |> Set.filter (isDead grid)

let cellStaysAlive grid cell =
    let cellAliveNeighbours = aliveNeighbours grid cell
    cellAliveNeighbours = 2 || cellAliveNeighbours = 3

let cellIsRevived grid cell = aliveNeighbours grid cell = 3

let aliveCells grid = Set.filter (cellStaysAlive grid) grid

let reviveCells grid =
    Seq.collect (deadNeighbours grid) grid
    |> Seq.filter (cellIsRevived grid)

let nextGeneration grid =
    Seq.append (aliveCells grid) (reviveCells grid)