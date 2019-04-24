using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class Pathfinder {

        public Tile[][] tiles;
        public Tile startTile;
        public Tile endTile;
        public Tile currentTile;
        public List<Tile> openTiles;
        public List<Tile> closedTiles;

        public Pathfinder() {

        }

        public bool searchPath(Tile[][] ttiles, Tile sTile, Tile eTile) {
        tiles = ttiles; // world grid
        startTile = sTile; // when the search begins
        endTile = eTile; // where the search ends
        openTiles = new List<Tile>(); // possible tiles for a path
        closedTiles = new List<Tile>(); // not a path

        openTiles.Add(startTile); // Add first tile to a possible path
        /* A* Algorithm */
        while (openTiles.Count > 0) {
            currentTile = openTiles[0]; // Search begins from the beginning
            for (int i = 0; i < openTiles.Count; i++) {
                /* Search for a tile that's more optimal than the current one */
                if (openTiles[i].getTotalCost() < currentTile.getTotalCost() || openTiles[i].getTotalCost() == currentTile.getTotalCost() && openTiles[i].getHeuristic() < currentTile.getHeuristic()) {
                    currentTile = openTiles[i];
                }
            }
            /* Throw current tile into the closed list */
            openTiles.Remove(currentTile);
            closedTiles.Add(currentTile);
            /* If the current tile is the end tile, we're finished! */
            if (currentTile == endTile) {
                /* Hurray! */
                return true;
            }
            else {
                /* Let's search all four tiles adjacent to the current tile if any of them is more optimal*/
                List<Tile> adjacents = getAllAdjacentTiles(currentTile); // Get the adjacents
                foreach (Tile t in adjacents) {
                    /* If an adjacent tile is already in the closed list on it's a wall, let's skip */
                    if (closedTiles.Contains(t) || !t.isWalkable()) {
                        continue;
                    }
                    /* Calculate the new travel cost (F-cost + H-cost) */
                    int newTravelCost = currentTile.getCost() + getDistance(currentTile, t);
                    if (newTravelCost < t.getCost() || !openTiles.Contains(t)) {
                        /* If we find an optimal tile, let's set the previous tile as its parent so we can retrace the path later */
                        t.setCost(newTravelCost);
                        t.setHeuristic(getManhattan(t));
                        t.setParent(currentTile);

                        if (!closedTiles.Contains(t)) {
                            openTiles.Add(t);
                        }
                    }
                }
            }
        }
        /* No path found, return false */
        return false;
    }

        public Tile getLowestCost(List<Tile> openList) {
            Tile lowestTotalCostTile = null;
            int lowestTotal = int.MaxValue;

            foreach(Tile t in openList) {
                if(tiles[t.getCoordX()][t.getCoordY()].getTotalCost() <= lowestTotal) {
                    lowestTotal = tiles[t.getCoordX()][t.getCoordY()].getTotalCost();
                    lowestTotalCostTile = tiles[t.getCoordX()][t.getCoordY()];
                }
            }
            return lowestTotalCostTile;
        }

        public List<Tile> getAdjacentTiles(Tile t) {
            List<Tile> adjacentTiles = new List<Tile>();
                for (int i = -1; i <= 1; i++) {
                    for (int j = -1; j <= 1; j++) {
                        if ((i == 0 && j == 0) || (Math.Abs(i*j) == 1) || !tiles[t.getCoordX() + i][t.getCoordY() + j].getWalkable()) {
                            continue;
                        }
                        try {
                            adjacentTiles.Add(tiles[t.getCoordX() + i][t.getCoordY() + j]);
                        }catch(Exception e) {
                            continue;
                        }
                    }
                }
            return adjacentTiles;
        }

    public List<Tile> getAllAdjacentTiles(Tile t) {
        List<Tile> adjacentTiles = new List<Tile>();
        try {
            adjacentTiles.Add(tiles[t.getCoordX() - 1][t.getCoordY()]);
            adjacentTiles.Add(tiles[t.getCoordX() + 1][t.getCoordY()]);
            adjacentTiles.Add(tiles[t.getCoordX()][t.getCoordY() - 1]);
            adjacentTiles.Add(tiles[t.getCoordX()][t.getCoordY() + 1]);
        }catch(Exception e) {
        
        }
        return adjacentTiles;
    }

    public int getManhattan(Tile t) {
            int manhattan = Math.Abs((endTile.getCoordX() - t.getCoordX())) + Math.Abs((endTile.getCoordY() - t.getCoordY()));
            return manhattan;
        }

    public int getDistance(Tile t, Tile u) {
        int dstX = Math.Abs(u.getCoordX() - t.getCoordX());
        int dstY = Math.Abs(u.getCoordY() - t.getCoordY());
        return dstX + dstY;
    }

    public List<Tile> getShortestPath(Tile[][] ttiles, Tile sTile, Tile eTile) {
        tiles = ttiles;
        startTile = sTile;
        endTile = eTile;
        openTiles = new List<Tile>();
        closedTiles = new List<Tile>();

        openTiles.Add(startTile);
        while (openTiles.Count > 0) {
            currentTile = openTiles[0];
            for(int i = 0; i < openTiles.Count; i++) {
                if(openTiles[i].getTotalCost() < currentTile.getTotalCost() || openTiles[i].getTotalCost() == currentTile.getTotalCost() && openTiles[i].getHeuristic() < currentTile.getHeuristic()) {
                    currentTile = openTiles[i];
                }
            }
            openTiles.Remove(currentTile);
            closedTiles.Add(currentTile);
            if (currentTile == endTile) {
                return retracePath(startTile, endTile);
            }
            else {
                List<Tile> adjacents = getAllAdjacentTiles(currentTile);
                foreach (Tile t in adjacents) {
                    if (closedTiles.Contains(t)) {
                        continue;
                    }
                    int newTravelCost = currentTile.getCost() + getDistance(currentTile, t);
                    if (newTravelCost < t.getCost() || !openTiles.Contains(t)) {
                        t.setCost(newTravelCost);
                        t.setHeuristic(getManhattan(t));
                        t.setParent(currentTile);

                        if (!closedTiles.Contains(t)) {
                            openTiles.Add(t);
                        }
                    }
                }
            }
        }
        //Console.WriteLine("Retracing path...");
        return retracePath(startTile, endTile);
    }

    public List<Tile> getPath(Tile[][] ttiles, Tile sTile, Tile eTile) {
        tiles = ttiles;
        startTile = sTile;
        endTile = eTile;
        openTiles = new List<Tile>();
        closedTiles = new List<Tile>();

        openTiles.Add(startTile);
        while (openTiles.Count > 0) {
            currentTile = openTiles[0];
            for (int i = 0; i < openTiles.Count; i++) {
                if (openTiles[i].getTotalCost() < currentTile.getTotalCost() || openTiles[i].getTotalCost() == currentTile.getTotalCost() && openTiles[i].getHeuristic() < currentTile.getHeuristic()) {
                    currentTile = openTiles[i];
                }
            }
            openTiles.Remove(currentTile);
            closedTiles.Add(currentTile);
            if (currentTile == endTile) {
                return retracePath(startTile, endTile);
            }
            else {
                List<Tile> adjacents = getAllAdjacentTiles(currentTile);
                foreach (Tile t in adjacents) {
                    if (closedTiles.Contains(t) || !t.isWalkable()) {
                        continue;
                    }
                    int newTravelCost = currentTile.getCost() + getDistance(currentTile, t);
                    if (newTravelCost < t.getCost() || !openTiles.Contains(t)) {
                        t.setCost(newTravelCost);
                        t.setHeuristic(getManhattan(t));
                        t.setParent(currentTile);

                        if (!closedTiles.Contains(t)) {
                            openTiles.Add(t);
                        }
                    }
                }
            }
        }
        return retracePath(startTile, endTile);
    }

    public List<Tile> retracePath(Tile start, Tile end) {
        List<Tile> path = new List<Tile>();
        Tile currentTile = end;
        while(currentTile != start) {
            path.Add(currentTile);
            currentTile = currentTile.getParentTile();
        }
        path.Reverse();
        return path;
    }

    }
