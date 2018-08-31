import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskrowComponent } from './taskrow.component';

describe('TaskrowComponent', () => {
  let component: TaskrowComponent;
  let fixture: ComponentFixture<TaskrowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskrowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskrowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
