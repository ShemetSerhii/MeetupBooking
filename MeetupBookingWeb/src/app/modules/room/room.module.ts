import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from "@angular/forms";
import { RoomRoutingModule } from './room-routing.module';
import { RoomListComponent } from './components/room-list/room-list.component';


@NgModule({
    declarations: [RoomListComponent],
    imports: [
    CommonModule,
    FormsModule,
    RoomRoutingModule
  ]
})

export class RoomModule { }