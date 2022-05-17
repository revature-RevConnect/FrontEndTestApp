import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { Post } from 'src/Interfaces/Post';

@Component({
  selector: 'app-postfeed',
  templateUrl: './postfeed.component.html',
  styleUrls: ['./postfeed.component.css']
})
export class PostfeedComponent implements OnInit {
  @Input()posts!:Post[];
  @Input() authID!:any;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    //this.api.getAllPosts().subscribe((allPosts)=>(this.posts=allPosts))
  }

}
