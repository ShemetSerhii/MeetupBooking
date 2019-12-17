import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/core/services/room.service';
import { RoomViewModel } from 'src/app/core/models/roomViewModel';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css'],
})
export class RoomListComponent implements OnInit {

  rooms: RoomViewModel[];

  constructor(
    private roomService: RoomService
  ) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.roomService.getRooms().subscribe((data => this.rooms = data));
  }


}
