import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { ApiService } from 'src/app/services/api.service';
import { Post } from 'src/Interfaces/Post';
import { Like } from 'src/Interfaces/Like';
import { Comment } from 'src/Interfaces/Comment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() post!:Post;
  @Input() authID:any;
  postLikes!:Like[];
  postComments!:Comment[];

  constructor(public auth:AuthService, private api:ApiService) { }

  ngOnInit(): void {
    this.api.getAllPostLikes(this.post.postID).subscribe((likes)=>this.postLikes=likes);
    this.api.getAllPostComments(this.post.postID).subscribe((comments)=>this.postComments=comments);
    
  }

  submitLike(){
    const newLike={
      likeID:0,
      postLikeID:this.post.postID,
      commentLikeID:0,
      authID:this.authID

    }
    console.log(newLike);
    this.api.likePost(newLike).subscribe((like)=>(this.postLikes.push(like)));
  }

  submitComment(newComment:Comment){
    this.api.commentOnPost(newComment).subscribe
  }

}
