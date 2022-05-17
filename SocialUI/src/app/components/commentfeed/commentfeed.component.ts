import { Component, OnInit } from '@angular/core';
import { Comment } from 'src/Interfaces/Comment';

@Component({
  selector: 'app-commentfeed',
  templateUrl: './commentfeed.component.html',
  styleUrls: ['./commentfeed.component.css']
})
export class CommentfeedComponent implements OnInit {
  showComments!:boolean;
  comments!:Comment[];

  constructor() { }

  ngOnInit(): void {
  }

}
