export interface NavalBattleGame {
    id: string;
    sizeInX: number;
    sizeInY: number;
    allPlayersOnline: boolean;
}

export interface Boat {
    id: string;
    direction: Direction;
    points: PointInBoat[];
    die: boolean;
}

export interface PointInBoat extends Point {
    beaten: boolean;
}

export interface Point {
    x: number;
    y: number;
}


export enum Direction {
    North = 1,
    South = 2,
    West = 3,
    East = 4,
}

