import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser'
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import './rxjs-extensions';

import { AppComponent } from './components/main/app';

import { GithubService } from './services/github';

import { AppRoutingModule } from './app-routing.module';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  declarations: [
    AppComponent
  ],
  providers: [
    GithubService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
