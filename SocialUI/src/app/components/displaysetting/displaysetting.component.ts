import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/Interfaces/UserSocial';

@Component({
  selector: 'app-displaysetting',
  templateUrl: './displaysetting.component.html',
  styleUrls: ['./displaysetting.component.css']
})
export class DisplaysettingComponent implements OnInit {
  @Input() user!:any;
  @Output() onSubmitPicture: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitUsername: EventEmitter<UserSocial>=new EventEmitter();
  @Output() onSubmitAboutMe: EventEmitter<UserSocial>=new EventEmitter();
  userSocial!:UserSocial;
  picture!:any;
  name!:any;
  aboutMe!:any;
  postedFile!:File;
  imgUrl!:any;
  imagePath!:any;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data)
    //;
  }

  // submitPicture(){
  //   console.log(this.user);
  //   this.userSocial={
  //     authID:this.user.sub,
  //     name:this.userSocial.name,
  //     profilePicture:this.picture,
  //     aboutMe:this.userSocial.aboutMe
  //   }
  //   this.onSubmitPicture.emit(this.userSocial);
  // }

  submitUsername(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.userSocial.aboutMe
    }
    this.onSubmitUsername.emit(this.userSocial);
  }

  submitAboutMe(){
    console.log(this.user);
    this.userSocial={
      authID:this.user.sub,
      name:this.userSocial.name,
      profilePicture:this.userSocial.profilePicture,
      aboutMe:this.aboutMe
    }
    this.onSubmitAboutMe.emit(this.userSocial);
  }


  onFileSelected(event: any) 
  {   
    this.postedFile=<File>event.target.files[0]; 
    console.log(this.postedFile);

    // var reader=new FileReader();
    // reader.onload=(_event)=>this.imgUrl=reader.result;
    // reader.readAsDataURL(this.postedFile);
    // console.log(this.imgUrl);
    //this.userSocial.profilePicture=this.imgUrl;
  }

  onUpload(){
    const formData:FormData = new FormData();
    formData.append('postedFile', this.postedFile, this.user);
    //console.log(formData);

    const photo = {
      authID:this.userSocial.authID,
      data:formData,
    }
    //this.api.postPicture(photo).subscribe((data)=>this.userSocial.profilePicture=data);
    this.onSubmitPicture.emit(photo);
    
  }

}
