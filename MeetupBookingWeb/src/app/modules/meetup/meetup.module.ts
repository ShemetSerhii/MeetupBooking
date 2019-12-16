import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from "@angular/forms";
import { MeetupListComponent } from './components/meetup-list/meetup-list.component';
import { MeetupRoutingModule } from './meetup-routing.module';



@NgModule({
    declarations: [MeetupListComponent],
    imports: [
    CommonModule,
    FormsModule,
    MeetupRoutingModule
  ]
})

export class MeetupModule { }
