import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SharedModule } from './shared/shared.module';
import { AbmModule } from './abm/abm.module';
import { MaterialModule } from './material/material.module';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AbmModule,
    SharedModule,
    MaterialModule,
    HttpClientModule   
  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
