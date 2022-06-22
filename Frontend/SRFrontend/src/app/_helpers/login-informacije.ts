
export class LoginInformacije {
  autentifikacijaToken: AutentifikacijaToken = null as any;
  isLogiran: boolean = false;
}

export interface AutentifikacijaToken {
  id: number;
  vrijednost: string;
  korisnickiNalogId: number;
  korisnickiNalog: KorisnickiNalog;
  vrijemeEvidentiranja: Date;
}
export interface KorisnickiNalog {
  id: number;
  korisnickoIme: string;
}
