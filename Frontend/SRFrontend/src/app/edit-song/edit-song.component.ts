import { Component, OnInit } from '@angular/core';
import {HttpClient } from "@angular/common/http";
import { ActivatedRoute } from '@angular/router';

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
  
  constructor(private httpKlijent: HttpClient,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.LoadSong();
    this.LoadCategorys();
  }

  btnAddSong() {

    console.log(this.song)
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
