import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddSongPageComponent } from './add-song-page/add-song-page.component';
import { EditSongComponent } from './edit-song/edit-song.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { SongPageComponent } from './song-page/song-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginPageComponent },
  { path: 'registration', component: RegistrationPageComponent },
  { path: 'add-song', component: AddSongPageComponent },
  { path: 'edit-song/:id', component: EditSongComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
