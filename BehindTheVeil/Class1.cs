// #define VALIDATE_HACK
#define BEHIND_VEIL
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Linq.ObservableImpl;

namespace BehindTheVeil {

public static class _AOTFixer {

  public static void DoThing() {
    var list = Observable.Range(1, 10)
      .Select(x => x + 1)
      .ToList();
  }

  public static void GenScheduleAction() {
    Scheduler.ScheduleAction<Tuple<Timer.Single, long>>(null, null, null);
    Scheduler.ScheduleAction<Tuple<Timer.Periodic, long>>(null, null, null);


    // Scheduler.Schedule<(Action<(Producer<long, Timer.Single._>, Timer.Single._)>,
    GenSchedule0<(Action<(Producer<long, Timer.Single._>, Timer.Single._)>,
                         (Producer<long, Timer.Single._>, Timer.Single._))>();
  }

  public static void GenSchedule0<T>() {
    // var x = default(ValueTuple<T,T>);
    CurrentThreadScheduler s = null;
    s.Schedule<T>(default(T), null);
  }

  /*
    CurrentThreadScheduler.Schedule<(Action<(Producer<long, Timer.Single._>, Timer.Single._)>, (Producer<long,Timer.Single._>, Timer.Single._))>()

CurrentThreadScheduler.Schedule<ValueTuple`2[[Action`1[[ValueTuple`2[[Producer`2[[Int64],[Timer+Single+_]],[Timer+Single+_]]]]],[ValueTuple`2[[Producer`2[[Int64],[Timer+Single+_]]],[Timer+Single+_]]]]>' for which no ahead of time (AOT) code was generated.

ExecutionEngineException: Attempting to call method 'System.Reactive.Concurrency.CurrentThreadScheduler::Schedule<System.ValueTuple`2[[System.Action`1[[System.ValueTuple`2[[System.Reactive.Producer`2[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Reactive.Linq.ObservableImpl.Timer+Single+_, System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263]], System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263],[System.Reactive.Linq.ObservableImpl.Timer+Single+_, System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.ValueTuple`2[[System.Reactive.Producer`2[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Reactive.Linq.ObservableImpl.Timer+Single+_, System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263]], System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263],[System.Reactive.Linq.ObservableImpl.Timer+Single+_, System.Reactive, Version=4.1.0.0, Culture=neutral, PublicKeyToken=94bc3704cddfc263]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]>' for which no ahead of time (AOT) code was generated.
  at System.Reactive.Concurrency.LocalScheduler.Schedule[TState] (TState state, System.Func`3[T1,T2,TResult] action) [0x00000] in <00000000000000000000000000000000>:0
  at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
  at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
  at TryToDoAThing.Start () [0x00000] in <00000000000000000000000000000000>:0

(Filename: currently not available on il2cpp Line: -1)
*/
  public static void GenScheduleAction<T>() {
#if BEHIND_VEIL
    // XXX: Try to get the types by grabbing them from Desktop where it actually runs.
    /*NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
      at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
      at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
      at TryToDoAThing+<Start>d__2.MoveNext () [0x00000] in <00000000000000000000000000000000>:0
      at UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) [0x00000] in <00000000000000000000000000000000>:0

      NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
      at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
      at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
      at TryToDoAThing.Start () [0x00000] in <00000000000000000000000000000000>:0

      (Filename: currently not available on il2cpp Line: -1)
      */
    Scheduler.ScheduleAction<T>(null, default(T), null);
    // Scheduler.ScheduleAction<Tuple<Producer<T,IDisposable>, T>>(null, null, null);
    // Scheduler.ScheduleAction<Tuple<Producer<T,Single._>, T>>(null, null, null);
    // Scheduler.ScheduleAction<Tuple<Single, T>>(null, null, null);
#endif
  }

#if VALIDATE_HACK

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
#endif

}
}
