Known Issues
============


###Known Issues
* Mono threads will currently only run on thread 4.
* Image effects from the Standard Assets package are not modified to benefit from RenderTexture.DiscardContents.
* Xbox APIs are not finalized yet and might change in the future.

###Known Crashes
* Certain crashes are developer's responsibility to fix and are not handled by Unity:
1. It is mandatory to have at least one Rich Presence string in the Xbox Live game configuration. Failing to do so will cause a crash in `SendToLive@PresenceCollection` (see callstack).
