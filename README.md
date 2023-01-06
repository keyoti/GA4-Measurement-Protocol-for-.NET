# GA4-Measurement-Protocol-for-.NET
Preliminary .NET Library for sending events to Google Analytics 4

This isn't fleshed out yet but you can send simple events to GA4 using it.  User properties are still to be implemented, and I welcome any 
pull requests with new features etc!

```
            Tracker t = new Tracker("testClient1", "1", "<your measurement ID, eg. G-G....>", "<your API secret>", null);

            var ev = new MeasurementEvent("test_event5");
            ev.AddParameter("customparam", 12);
            ev.AddParameterItem(new ParameterItem() { ItemName = "test1" });
            ev.AddParameterItem(new ParameterItem() { ItemName = "test2" });
            await t.AddEventAsync(ev);
            await t.SendEventsAsync();
```


Protocol documentation: https://developers.google.com/analytics/devguides/collection/protocol/ga4



Unsure if these are helpful yet.
See https://www.simoahava.com/analytics/implementation-guide-events-google-analytics-4/ for what to do with the data you send.

DebugView https://support.google.com/analytics/answer/7201382


