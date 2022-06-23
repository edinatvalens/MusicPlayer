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
  

    showModal1:boolean=false;
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
    this.httpKlijent.get("https://localhost:44308/Favorites/GetbyUser?id=1")
    .subscribe(x=>{
      console.log("Favorites", x);
      this.Favorites=x;
    });
    
  }
}
