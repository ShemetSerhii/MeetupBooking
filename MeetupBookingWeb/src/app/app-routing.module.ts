import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
      path: 'meetup',
      loadChildren: () => import('./modules/meetup/meetup.module').then(mod => mod.MeetupModule)
  },
  {
    path: 'room',
    loadChildren: () => import('./modules/room/room.module').then(mod => mod.RoomModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
