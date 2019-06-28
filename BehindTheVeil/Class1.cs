#define BEHIND_VEIL
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace BehindTheVeil {

public static class _AOTFixer {

  public static void DoThing() {
    var list = Observable.Range(1, 10)
      .Select(x => x + 1)
      .ToList();
  }

  public static void GenScheduleAction<T>() {
#if BEHIND_VEIL
    // XXX: Try to get the types by grabbing them from Desktop where it actually runs.
    /*NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
      at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0 
      at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0 
      at TryToDoAThing+<Start>d__2.MoveNext () [0x00000] in <00000000000000000000000000000000>:0 
      at UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) [0x00000] in <00000000000000000000000000000000>:0
      */
    Scheduler.ScheduleAction<T>(null, default(T), null);
    // Scheduler.ScheduleAction<Tuple<Producer<T,IDisposable>, T>>(null, null, null);
    // Scheduler.ScheduleAction<Tuple<Producer<T,Single._>, T>>(null, null, null);
    Scheduler.ScheduleAction<Tuple<Single, T>>(null, null, null);
#endif
  }

  public static void GenSchedule<T>() {
    var timeSpan = TimeSpan.Zero;
    var dateTimeOffset = DateTimeOffset.UtcNow;
    IScheduler ischeduler = null;
    // Scheduler
    //   .Schedule<T>(default(T), null);
    ischeduler
      .Schedule<T>(default(T), null);

    ischeduler
      .Schedule<T>(default(T), timeSpan, null);

    ischeduler
      .Schedule<T>(default(T), dateTimeOffset, null);

    Scheduler
      .Schedule<T>(null, default(T), null);
  }

}
}
