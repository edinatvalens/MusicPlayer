import { Component, OnInit } from '@angular/core';
import {HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-add-song-page',
  templateUrl: './add-song-page.component.html',
  styleUrls: ['./add-song-page.component.css']
})
export class AddSongPageComponent implements OnInit {

  sName: any;
  sArtist: any;
  sUrl: any;
  sLenght: any;
  sCategory: any;


  Categories:any;

  constructor(private httpKlijent: HttpClient) { }

  ngOnInit(): void {
    this.LoadCategorys();
  }
  
  LoadCategorys(){
    
    this.httpKlijent.get("https://localhost:44308/SongCategory/GetAll")
    .subscribe(x=>{
      console.log("Categorys", x);
      this.Categories = x;
    });

  }

  btnAddSong() {
    let saljemo = {
      SongName: this.sName,
      ArtristName: this.sArtist,
      SongUrl: this.sUrl,
      AddedDate: new Date(),
      EditDate: new Date(),
      SongCategoryID: Number(this.sCategory),
      SongLenght:this.sLenght
    };
    console.log(saljemo);
    this.httpKlijent.post("https://localhost:44308/Song/Add", saljemo)
      .subscribe((x: any) => {
        if (x != null) {
       
          alert("Song added succesfuly!");
          
        }
        else {
          alert("Failed, please try again!");
        }
      });
  }

}
