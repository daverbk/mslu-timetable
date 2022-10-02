Flow:

1. GET to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport

2. CHANGE FACULTY => POST to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.faculty:change  param : t:zoneid = studyGroupZone

3. CHANGE COURSE => POST to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.course:change param : t:zoneid = studyWeekZone

4. CHANGE YEAR => POST to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.studyyears:change param : t:zoneid = studyWeekZone

5. CHANGE GROUP => POST to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.studygroups:change param : t:zoneid = buttonZone

6. CHANGE WEEK => POST to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.studyweeks:change param : t:zoneid = buttonZone

7. GET THE .xls => GET to http://raspisanie.mslu.by/schedule/reports/publicreports/schedulelistforgroupreport.printreport

Parameters for POST methods:

- t:zoneid — value
- t:formid — printForm
- t:formcomponentid — reports/publicreports/ScheduleListForGroupReport:printform
- t:selectvalue — value
