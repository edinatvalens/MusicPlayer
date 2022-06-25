import { Component, OnInit } from '@angular/core';
import {HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
    Songs:any;
    Categories:any;
    Zam:any;
    searchtext:any;
    Favorites:any;
    totalLength:any;
    page:number = 1;
    Rating:any;
    isLog:boolean=AutentifikacijaHelper.getLoginInfo().isLogiran;
    clicked:any;
    showModal1:boolean=false;
    showSongM:boolean=false;
    showMain:boolean=true;

    

  constructor(private httpKlijent: HttpClient,private  router :Router) { }

  onClick()
  {
    this.showMain=false;
    this.showModal1 = true;

  }
  
  hide()
  {
    this.showModal1 = false;
    this.showMain=true;
    this.showSongM=false;


  }
  showSong(s:any){
    this.showSongM=true;
    this.showModal1 = false;
    this.showMain=false;
    this.clicked=s;
  }



  ngOnInit(): void {
    this.LoadSongs();
    this.LoadCategorys();
  }
    LoadSongs(){
    
    this.httpKlijent.get("https://localhost:44308/Song/GetAll")
    .subscribe(x=>{
      console.log("Songs", x);
      this.Songs = x;
      this.Zam=x;
    });

  }
  LoadCategorys(){
    
    this.httpKlijent.get("https://localhost:44308/SongCategory/GetAll")
    .subscribe(x=>{
      console.log("Categorys", x);
      this.Categories = x;
    });

  }
  Filter(id:any){
    if(id=='All'){
      this.LoadSongs();
    }
    if(id!=null){
      return this.Songs=this.Zam.filter((x:any)=> x.song_Category_id==id);
    }
  }
  Search()
  {
    if(this.searchtext=="")
    {
      this.Songs=this.Zam;
    }
    else {
     return this.Songs=this.Zam.filter((x:any)=> x.songName.toLowerCase().includes(this.searchtext));
    }
  }

  LoadFavorites(){
    this.httpKlijent.get("https://localhost:44308/Favorites/GetbyUser?id="+AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId)
    .subscribe(x=>{
      console.log("Favorites", x);
      this.Favorites=x;
    });
    
  }
  AddToFavorites(song:any){
    if(AutentifikacijaHelper.getLoginInfo().isLogiran==false){
      alert("You must be logged in to add song to favorites!")
    }
    if(AutentifikacijaHelper.getLoginInfo().isLogiran==true){
    let saljemo = {
      userID: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      songID: song
    };

    this.httpKlijent.post("https://localhost:44308/Favorites/Add", saljemo)
      .subscribe((x: any) => {
        if (x == true) {
          alert("Song added successfuly to favorites!");
    
        }
        else {
          alert("Error, song is already in your favorites!");
        }
      });
    }
  }
  DeleteFromFavorites(id:any){
       let userID:any = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId;

    this.httpKlijent.delete("https://localhost:44308/Favorites/Delete?idU="+userID+"&idS="+id)
    .subscribe((x: any) => {
      if (x != null) {
        alert("Song deleted successfuly to favorites!");
        this.LoadFavorites();
      }
      else {
        alert("Error, something went wrong!");
      }
    });
  }
  RateSong(id:any, rate:any, isFav:boolean){
    if(AutentifikacijaHelper.getLoginInfo().isLogiran==false){
      alert("You must be logged in to rate song!")
    }
    if(AutentifikacijaHelper.getLoginInfo().isLogiran==true){
    let saljemo={
      songID: id,
      userID: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      rating: rate

    }
    this.httpKlijent.post("https://localhost:44308/VoteRating/Add", saljemo)
    .subscribe((x: any) => {
      
      if (x != null) {
        alert("Song rated successfuly!");
        this.LoadSongs();
        if(isFav==true){
        this.LoadFavorites();
        }
      }
      else {
        alert("Error, you need to be logged in to add in favorites!");
      }
    });
  }
  }
}
