import {Injectable, Pipe, PipeTransform} from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Pipe({
  name: 'youtube'
})
@Injectable()

export class SafePipe implements PipeTransform {

  constructor(private dom: DomSanitizer) { }

  transform(value :any) {
    return this.dom.bypassSecurityTrustResourceUrl(value);
  }

}