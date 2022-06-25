import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { NgxPaginationModule } from "ngx-pagination";
import { SongPageComponent } from './song-page/song-page.component';
import { SafePipe } from './safe.pipe';
import { AddSongPageComponent } from './add-song-page/add-song-page.component';
import { EditSongComponent } from './edit-song/edit-song.component';


@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    SongPageComponent,
    SafePipe,
    AddSongPageComponent,
    EditSongComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxPaginationModule,
    
  ],
  providers: [SafePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
