import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { UserSocial } from 'src/Interfaces/UserSocial';
import { AuthService, User } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  picture!:any;
  user!:any;
  userSocial!:UserSocial;

  constructor(private api:ApiService, public auth:AuthService) { }

  ngOnInit(): void {
    this.auth.user$.subscribe((data)=>this.user=data)
  }

  // onSubmit(){
  //   console.log(this.user);
  //   this.userSocial={
  //     authID:this.user.sub,
  //     username:this.user.email,
  //     profilePicture:this.picture
  //   }
  //   console.log(this.userSocial);
  //   this.onSubmitPicture.emit(this.userSocial);
  // }

  getUserProfile(){
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data);
    console.log(this.userSocial);
  }

  updateUserPicture(photo:any){
    this.api.postPicture(photo).subscribe((data)=>this.user=data);
    //this.api.updatePicture(userSocial).subscribe((data)=>this.user=data);
    //console.log(userSocial);
    //window.location.replace('/settings')
  }

  updateUsername(userSocial:UserSocial){
    this.api.updateUsername(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

  updateAboutMe(userSocial:UserSocial){
    this.api.updateAboutMe(userSocial).subscribe((data)=>this.user=data);
    console.log(userSocial);
  }

}
