#include "helper.h"

struct time timeUpdate(struct time now)
{
  ++now.seconds;

  if(now.seconds == 60) {
    now.seconds = 0;
    ++now.minutes;

    if(now.minutes == 60) {
      now.minutes = 0;
      ++now.hour;

      if(now.hour == 24) {
        now.hour = 0;
      }
    }
  }

  return now;
}
