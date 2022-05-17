import { Component, OnInit, EventEmitter, Output,Input } from '@angular/core';
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/Interfaces/UserSocial';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  picture!:string;
  user!:any;
  //userSocial!:UserSocial;

  constructor(public auth: AuthService, private api:ApiService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data) 
  }

  // updateUserPicture(userSocial:UserSocial){
  //   this.api.updatePicture(userSocial).subscribe((data)=>this.user=data);
  //   console.log(userSocial);
  // }

}
