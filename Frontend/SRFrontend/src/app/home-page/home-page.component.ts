import { Component, OnInit } from '@angular/core';
import {HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
    Songs:any;
  constructor(private httpKlijent: HttpClient,private  router :Router) { }

  ngOnInit(): void {
    this.LoadSongs();
  }
    LoadSongs(){
    
    this.httpKlijent.get("https://localhost:44308/Song/GetAll")
    .subscribe(x=>{
      console.log("Songs", x);
      this.Songs = x;
    });

  }
}
