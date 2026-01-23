import { Component, Input } from '@angular/core';
import { Activity } from '../models/activity';

@Component({
  selector: 'app-activity-item',
  imports: [],
  templateUrl: './activity-item.html',
  styleUrl: './activity-item.scss',
})
export class ActivityItem {
  @Input()
  activity!: Activity;
}
