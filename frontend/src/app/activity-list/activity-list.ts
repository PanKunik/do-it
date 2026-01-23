import { Component } from '@angular/core';
import { Activity } from '../models/activity';
import { ActivityItem } from '../activity-item/activity-item';

@Component({
  selector: 'app-activity-list',
  imports: [ActivityItem],
  templateUrl: './activity-list.html',
  styleUrl: './activity-list.scss',
})
export class ActivityList {
  activities: Activity[] = [
    { Name: "Activity #1", Description: "Description #1", Status: false, Importance: false },
    { Name: "Activity #2", Status: true, Importance: false },
    { Name: "Activity #3", Status: false, Importance: true },
    { Name: "Activity #4", Description: "Description #4", Status: true, Importance: true }
  ];
}
