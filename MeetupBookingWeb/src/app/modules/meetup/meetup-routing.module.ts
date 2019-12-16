import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MeetupListComponent } from './components/meetup-list/meetup-list.component';

const routes: Routes = [
    { path: '', component: MeetupListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class MeetupRoutingModule { }