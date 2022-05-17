import { Component, OnInit,Input } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { UserSocial } from 'src/Interfaces/UserSocial';

@Component({
  selector: 'app-displayprofile',
  templateUrl: './displayprofile.component.html',
  styleUrls: ['./displayprofile.component.css']
})
export class DisplayprofileComponent implements OnInit {
  @Input() user:any;
  userSocial!:UserSocial

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.user.sub).subscribe((data)=>this.userSocial=data); 
  }

}
