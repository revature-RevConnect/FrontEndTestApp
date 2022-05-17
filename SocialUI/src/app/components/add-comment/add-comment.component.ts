import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Comment } from 'src/Interfaces/Comment';

@Component({
  selector: 'app-add-comment',
  templateUrl: './add-comment.component.html',
  styleUrls: ['./add-comment.component.css']
})
export class AddCommentComponent implements OnInit {
  body!:string;
  @Output() onSubmitComment:EventEmitter<Comment> = new EventEmitter();
  @Input() authID:any;

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(){
    const newComment={
      commentID:0,
      body:this.body, 
      authID:this.authID,
      commentLikes:null     
    }
    this.onSubmitComment.emit(newComment)

  }
}
