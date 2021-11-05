#include "helper.h"

struct time elapsed_time(struct time t1, struct time t2)
{
  int hour = t2.hour - t1.hour;
  int minutes = t2.minutes - t1.minutes;
  int seconds = t2.seconds - t1.seconds;

  if(minutes < 0) {
    hour -= 1;
    minutes += 60;
  }

  if(seconds < 0) {
    minutes -= 1;
    seconds += 60;
  }

  return (struct time) { .hour = hour, .minutes = minutes, .seconds = seconds };
}
