import { Component, OnInit } from '@angular/core';
import { AudioService } from '../audio.service';

@Component({
  selector: 'app-audio-list',
  templateUrl: './audio-list.component.html',
  styleUrls: ['./audio-list.component.css']
})
export class AudioListComponent implements OnInit {
  audios: any[] = [];

  constructor(private audioService: AudioService) {}

  ngOnInit(): void {
    this.audioService.getAudios().subscribe(data => {
      this.audios = data;
    });
  }
}
