import { Component, OnInit } from '@angular/core';
import {HttpClient } from "@angular/common/http";
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { SongPageComponent } from '../song-page/song-page.component';

@Component({
  selector: 'app-edit-song',
  templateUrl: './edit-song.component.html',
  styleUrls: ['./edit-song.component.css']
})
export class EditSongComponent implements OnInit {
  /*Varijabla za smjestanje pjesme koju je korisnik odlucio uredjivati*/
  song:any;
  /*Varijabla za provjeru id pjesme koju je korisnik odlucio uredjivati*/
  songID:any= Number(this.route.snapshot.paramMap.get('id'));
  /*Varijabla za smjestanje kategorija*/
  Categories:any;
  
  constructor(private httpKlijent: HttpClient,private route: ActivatedRoute,private  router :Router) { }

  ngOnInit(): void {
    this.LoadSong();
    this.LoadCategorys();
  }
 /*Funkcija za slanje novih podataka u bekend, obavjestenje o uspjesnosti*/
  btnEditSong() {

    let saljemo={
      songName: this.song.songName,
      artristName: this.song.artristName,
      songUrl: this.song.songUrl,
      songLenght: this.song.songLenght,
      songRating: this.song.songRating,
      addedDate: this.song.addedDate,
      editDate: new Date(),
      songCategoryID: Number(this.song.song_Category_id)
    }

    this.httpKlijent.post("https://localhost:44308/Song/EditSong/"+this.songID, saljemo)
    .subscribe((x: any) => {
      if (x != null) {
        alert("Song edited succesfuly!!");
        this.router.navigate(['']); /*U slucaju da je edit uspjesan, korisnik se salje na homepage*/
      }
      else {
        alert("Edit failed, please try again!");
      }
    });
  }
  /*Ucitavanje kategorija*/
  LoadCategorys(){
    this.httpKlijent.get("https://localhost:44308/SongCategory/GetAll")
    .subscribe(x=>{
      console.log("Categorys", x);
      this.Categories = x;
    });
  }
  /*Ucitavanje specificke pjesme*/
  LoadSong(){
    
    this.httpKlijent.get("https://localhost:44308/Song/Get/"+this.songID)
    .subscribe(x=>{
      console.log("Song", x);
      this.song = x;
      
    });

   
  }
}
