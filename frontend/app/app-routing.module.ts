import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './components/main/app';

const routes: Routes = [
  { path: '', redirectTo: '/issues', pathMatch: 'full' },
  { path: 'issues', component: AppComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }