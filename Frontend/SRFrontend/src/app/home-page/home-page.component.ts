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
    /*Varijabla za pjesme */
    Songs:any;
    /*Varijabla za pjesme, zamjenska radi lakseg filtriranja */
    Zam:any;
    /*Varijabla za kategorije */
    Categories:any;
    /*Varijabla za search */
    searchtext:any;
    Favorites:any;
   /*Varijable za paginaciju */
    totalLength:any;
    page:number = 1;

    Rating:any;
     /*Provjera da li je korisnik logiran, koristi se za prikaz buttona za favorite listu i provjeru da li je moguce
     ocjenjivanje proizvoda i dodavanje u favorite listu */
    isLog:boolean=AutentifikacijaHelper.getLoginInfo().isLogiran;
    clicked:any;
    /*Varijabla za modale, kada je odredjeni modal true, prikazati ce se */
    showModal1:boolean=false;
    showSongM:boolean=false;
    showMain:boolean=true;

    

  constructor(private httpKlijent: HttpClient,private  router :Router) { }

  showFavorites()/*prikaz favorite liste, sakrivanje main */
  {
    this.showMain=false;
    this.showModal1 = true;

  }
  
  hide()/*Prikaz main dijela, sakrivanje song i favorites u zavsnosti koji je true*/
  {
    this.showModal1 = false;
    this.showMain=true;
    this.showSongM=false;


  }

  showSong(s:any)/*prikaz specificne pjesme na klik, sakrivanje main i favorites kao i na klik spremanje pjesme za koju
  zelimo da vidimo detaljne informacije*/
  {
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

  Filter(id:any)/*Filter za prikazivanje kategorije koja je odabrana*/
  {
    if(id=='All'){
      this.LoadSongs();
    }
    if(id!=null){
      return this.Songs=this.Zam.filter((x:any)=> x.song_Category_id==id);
    }
  }

  Search()/*Search, istog momenta kad korisnik upise nesto u search input podatci se mjenjaju i filtriraju u zavisnosti od sadrzaja*/
  {
    if(this.searchtext=="")
    {
      this.Songs=this.Zam;
    }
    else {
     return this.Songs=this.Zam.filter((x:any)=> x.songName.toLowerCase().includes(this.searchtext.toLowerCase()));
    }
  }

  LoadFavorites(){
    this.httpKlijent.get("https://localhost:44308/Favorites/GetbyUser?id="+AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId)
    .subscribe(x=>{
      console.log("Favorites", x);
      this.Favorites=x;
    });
    
  }

  AddToFavorites(song:any)/*Funkcija za dodavanje u favorites, kao i restrikcija da dodavanje samo u slucaju
  da je korisnik logiran*/
  {
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

  DeleteFromFavorites(id:any)/*Brisanje iz favorite liste, userID vraca id korisnika a id pjesme koju je odlucio izbrisati
  prima sama funkcija*/
  {
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

  RateSong(id:any, rate:any, isFav:boolean)/*ocjenjivanje pjesme od 1 do 5, restrikcija za samo logirane korisnike*/
  {
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
      
      if (x == true) {
        alert("Song rated successfuly!");
        this.LoadSongs();
        if(isFav==true){
        this.LoadFavorites();
        }
      }
      else {
        alert("Error, you cant vote twice!");
      }
    });
  }
  }
}
