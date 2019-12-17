export class MeetupViewModel  {

    id: number;
    name: string;
    description: string;
    ownerName: string;
    rooms: Room[];
    participants: Participant[];
}

export class Participant{
    id: number;
    name: string;
}

export class Room{
    id: number;
    name: string;
}