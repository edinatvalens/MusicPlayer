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
  sName: any;
  sArtist: any;
  sUrl: any;
  sLenght: any;
  sCategory: any;
  song:any;
  songID:any= Number(this.route.snapshot.paramMap.get('id'));
  Categories:any;
  
  constructor(private httpKlijent: HttpClient,private route: ActivatedRoute,private  router :Router) { }

  ngOnInit(): void {
    this.LoadSong();
    this.LoadCategorys();
  }

  btnAddSong() {

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
        this.router.navigate(['']);
      }
      else {
        alert("Edit failed, please try again!");
      }
    });
  }

  LoadCategorys(){
    this.httpKlijent.get("https://localhost:44308/SongCategory/GetAll")
    .subscribe(x=>{
      console.log("Categorys", x);
      this.Categories = x;
    });
  }
  LoadSong(){
    
    this.httpKlijent.get("https://localhost:44308/Song/Get/"+this.songID)
    .subscribe(x=>{
      console.log("Song", x);
      this.song = x;
      
    });

   
  }
}
