import { Component, Input, OnInit } from '@angular/core';
import {DomSanitizer} from "@angular/platform-browser";
import { HttpClient } from "@angular/common/http";
import { Router } from '@angular/router';
import { AutentifikacijaHelper } from '../_helpers/autentifikacija-helper';

@Component({
  selector: 'app-song-page',
  templateUrl: './song-page.component.html',
  styleUrls: ['./song-page.component.css']
})
export class SongPageComponent implements OnInit {
  @Input() song:any;
  showVideo:boolean=false;
  showDetails:boolean=true;
  safeUrl:any;
  isLog:boolean=AutentifikacijaHelper.getLoginInfo().isLogiran;

  constructor(private sanitizer: DomSanitizer,private httpKlijent: HttpClient,private router: Router) { }

  ngOnInit(): void {
    console.log(this.song);
    console.log("songggg",this.song.songUrl);
    console.log("song",this.song.safeUrl);

  }
  onClick()
  {
    this.showDetails=false;
    this.showVideo=true;

  }
  
  hide()
  {
    this.showVideo = false;
    this.showDetails=true;

  }
  getSafeUrl(url:any){
    this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl("https://www.youtube.com/embed/XztaW2MXPKs%22");
  }
  DeleteSong(id:any){
    this.httpKlijent.delete("https://localhost:44308/Song/Delete/"+id)
    .subscribe((x: any) => {
      if (x != null) {
        alert("Song deleted!");
        this.router.navigateByUrl("");

      }
      else {
        alert("Error, something went wrong!");
      }
    });
  }

}
