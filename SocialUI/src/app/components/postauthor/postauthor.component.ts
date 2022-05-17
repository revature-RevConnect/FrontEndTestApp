import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { Post } from 'src/Interfaces/Post';

@Component({
  selector: 'app-postauthor',
  templateUrl: './postauthor.component.html',
  styleUrls: ['./postauthor.component.css']
})
export class PostauthorComponent implements OnInit {
  @Input() post!:Post;
  postAuthor!:any;

  constructor(private api:ApiService) { }

  ngOnInit(): void {
    this.api.getCurrentUser(this.post.authID).subscribe((author)=>this.postAuthor=author);
  }

}
