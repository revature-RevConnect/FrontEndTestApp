import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {
  user!:any;

  constructor(@Inject(DOCUMENT) public document: Document, public auth:AuthService, private api:ApiService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((profile)=>this.user=profile)
  }

  makeUserInactive(){
    console.log(this.user.sub);
    const userSocial={
      userID:0,
      authID:this.user.sub,
      active:false,
    };
    console.log(userSocial.authID);
    this.api.setUserToInactive(userSocial).subscribe();
  }

}
