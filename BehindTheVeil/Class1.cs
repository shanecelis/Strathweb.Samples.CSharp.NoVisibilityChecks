// #define VALIDATE_HACK
// #define BEHIND_VEIL
using System;
using System.Reactive;
using Reactive = System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ObservableImpl = System.Reactive.Linq.ObservableImpl;
using System.Reactive.Linq.ObservableImpl;

namespace BehindTheVeil {

public static class _AOTFixer {

  public static void DoThing() {
    var list = Observable.Range(1, 10)
      .Select(x => x + 1)
      .ToList();
  }

  public static void GenScheduleAction() {
    GenScheduleAction<(Timer.Single, long)>();
    // GenScheduleAction<(Timer.Periodic, long)>();
    GenScheduleAction<(Timer.Periodic, Timer.Periodic._)>();
    GenSchedule0<(Timer.Periodic, Timer.Periodic._)>();


    // Scheduler.Schedule<(Action<(Producer<long, Timer.Single._>, Timer.Single._)>,
    // For Timer
    // GenSchedule0<(Action<(Producer<long, Timer.Single._>, Timer.Single._)>,
    //                      (Producer<long, Timer.Single._>, Timer.Single._))>();
    GenSchedule0<(Action<(Timer.Single, Timer.Single._)>,
                         (Timer.Single, Timer.Single._))>();

    GenSchedule0<(Action<(Timer.Periodic, Timer.Periodic._)>,
                         (Timer.Periodic, Timer.Periodic._))>();

    GenScheduleAction<(Action<(Timer.Periodic, Timer.Periodic._)>,
                  (Timer.Periodic, Timer.Periodic._))>();

    // CurrentThreadScheduler.Instance.ScheduleAction(
    //                                                (@this: this, sink),
    //                                                tuple => tuple.@this.Run(tuple.sink));

    // For Interval
    // GenScheduleAction<(Producer<Reactive.TimeInterval<long>, ObservableImpl.TimeInterval<long>._>,
    //                     ObservableImpl.TimeInterval<long>._)>();

    GenScheduleAction<(ObservableImpl.TimeInterval<long>,
                       ObservableImpl.TimeInterval<long>._)>();
  }



  public static void GenSchedule0<T>() {
    // var x = default(ValueTuple<T,T>);
    CurrentThreadScheduler s = null;
    s.Schedule<T>(default(T), null);
  }


  public static void GenScheduleAction<T>() {
    GenScheduleAction0<T>();
    GenScheduleAction1<T>();
  }

  /*NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
    at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
    at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunAttempt (System.Int32 whichAttempt) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunButton () [0x00000] in <00000000000000000000000000000000>:0
    */
  public static void GenScheduleAction0<T>() {
    // var x = default(ValueTuple<T,T>);
    CurrentThreadScheduler s = null;
    s.ScheduleAction<T>(default(T), null);
  }

  /*NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
    at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
    at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunAttempt (System.Int32 whichAttempt) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunButton () [0x00000] in <00000000000000000000000000000000>:0

    (Filename: currently not available on il2cpp Line: -1)
  */
  public static void GenScheduleAction1<T>() {
    // Action action = null;
    // Scheduler.ScheduleAction<T>(null, default(T), null);
    IScheduler scheduler = null;
    Action<T> actionT = null;
    Scheduler.ScheduleAction<T>(scheduler, default(T), actionT);
    Func<T,IDisposable> func = null;
    Scheduler.ScheduleAction<T>(scheduler, default(T), func);
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
#if BEHIND_VEIL
  public static void GenScheduleAction<T>() {
    // XXX: Try to get the types by grabbing them from Desktop where it actually runs.
    /*
      NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
      at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
      at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
      at TryToDoAThing+<Start>d__2.MoveNext () [0x00000] in <00000000000000000000000000000000>:0
      at UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) [0x00000] in <00000000000000000000000000000000>:0
      */

    /*
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
  }
#endif

  public static void GenISchedule<T>() {
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
  }

  public static void GenSchedulePair<TState>() {
    GenISchedule<(Action<TState>, TState)>();
    Action<TState> action0 = null;
    Scheduler.ScheduleAction<TState>(null, default(TState), action0);
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

      /*
        Case 0
        ======

        Attempt 4.

        Observable.Interval(TimeSpan.FromSeconds(0.5f), unityScheduler)
        .Where(i => i % 2 == 0)
        .Subscribe((long i) => Log($"i {i}"));

        Xcode
        -----
    NotSupportedException: IL2CPP encountered a managed type which it cannot convert ahead-of-time. The type uses generic or array types which are nested beyond the maximum depth which can be converted.
    at System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) [0x00000] in <00000000000000000000000000000000>:0
    at System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunAttempt (System.Int32 whichAttempt) [0x00000] in <00000000000000000000000000000000>:0
    at TryToDoAThing.RunButton () [0x00000] in <00000000000000000000000000000000>:0

    Unity macOS
    -----------
    Schedule 1 StateSystem.ValueTuple`2[System.Int32,System.Action`2[System.Int32,System.Action`2[System.Int32,System.TimeSpan]]]
    Schedule 1 StateSystem.ValueTuple`2[System.ValueTuple`3[System.Int32,System.Reactive.Disposables.SingleAssignmentDisposable,System.Reactive.Concurrency.Scheduler+InvokeRec2State`1[System.Int32]],System.Action`1[System.ValueTuple`3[System.Int32,System.Reactive.Disposables.SingleAssignmentDisposable,System.Reactive.Concurrency.Scheduler+InvokeRec2State`1[System.Int32]]]]

    ValueTuple`2[Int32,Action`2[Int32,Action`2[Int32,TimeSpan]]]

    (int, Action<int, Action<int, TimeSpan>>)

    ValueTuple`2[ValueTuple`3[Int32,SingleAssignmentDisposable,Scheduler+InvokeRec2State`1[Int32]],Action`1[ValueTuple`3[Int32,SingleAssignmentDisposable,Scheduler+InvokeRec2State`1[Int32]]]]

    (        (int, SingleAssignmentDisposable, Scheduler.InvokeRec2State<int>),
      Action<(int, SingleAssignmentDisposable, Scheduler.InvokeRec2State<int>)>)

            */
  public static void Case0<T>() {
    GenISchedule<(T, Action<T, Action<T, TimeSpan>>)>();
    // GenISchedule<((T, SingleAssignmentDisposable, Scheduler.InvokeRec2State<T>),
    // GenISchedule<((T, SingleAssignmentDisposable, Scheduler.InvokeRec2State<T>),
    //        Action<(T, SingleAssignmentDisposable, Scheduler.InvokeRec2State<T>)>)>();
    GenSchedulePair<(T, SingleAssignmentDisposable, Scheduler.InvokeRec2State<T>)>();
  }
  /* Case 1
     ======
Exception: ugh
UnityScheduler.Schedule[T] (T state, System.TimeSpan dueTime, System.Func`3[T1,T2,TResult] action) (at Assets/UnityScheduler.cs:25)
System.Reactive.Concurrency.Scheduler.Schedule[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.TimeSpan dueTime, System.Action`2[T1,T2] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.Scheduler+SchedulePeriodicRecursive`1[TState].Start () (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.Scheduler.SchedulePeriodic_[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.TimeSpan period, System.Func`2[T,TResult] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.Scheduler.SchedulePeriodic[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.TimeSpan period, System.Action`1[T] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Linq.ObservableImpl.Timer+Periodic+_.Run (System.Reactive.Linq.ObservableImpl.Timer+Periodic parent, System.TimeSpan dueTime) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Linq.ObservableImpl.Timer+Periodic+Relative.Run (System.Reactive.Linq.ObservableImpl.Timer+Periodic+_ sink) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) (at <269857168607470d991a5a72ee3bb154>:0)
System.ObservableExtensions.SubscribeSafe[T] (System.IObservable`1[T] source, System.IObserver`1[T] observer) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Sink`2[TSource,TTarget].Run (System.IObservable`1[T] source) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Linq.ObservableImpl.Where`1+Predicate[TSource].Run (System.Reactive.Linq.ObservableImpl.Where`1+Predicate+_[TSource] sink) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Producer`2+<>c[TTarget,TSink].<SubscribeRaw>b__1_0 (System.ValueTuple`2[T1,T2] tuple) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.Scheduler+<>c__75`1[TState].<ScheduleAction>b__75_0 (System.Reactive.Concurrency.IScheduler _, System.ValueTuple`2[T1,T2] tuple) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.CurrentThreadScheduler.Schedule[TState] (TState state, System.TimeSpan dueTime, System.Func`3[T1,T2,TResult] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.LocalScheduler.Schedule[TState] (TState state, System.Func`3[T1,T2,TResult] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Concurrency.Scheduler.ScheduleAction[TState] (System.Reactive.Concurrency.IScheduler scheduler, TState state, System.Action`1[T] action) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Producer`2[TTarget,TSink].SubscribeRaw (System.IObserver`1[T] observer, System.Boolean enableSafeguard) (at <269857168607470d991a5a72ee3bb154>:0)
System.Reactive.Producer`2[TTarget,TSink].Subscribe (System.IObserver`1[T] observer) (at <269857168607470d991a5a72ee3bb154>:0)
System.ObservableExtensions.Subscribe[T] (System.IObservable`1[T] source, System.Action`1[T] onNext) (at <269857168607470d991a5a72ee3bb154>:0)
TryToDoAThing.Attempt4Works () (at Assets/TryToDoAThing.cs:57)
TryToDoAThing.RunAttempt (System.Int32 whichAttempt) (at Assets/TryToDoAThing.cs:206)
TryToDoAThing.RunButton () (at Assets/TryToDoAThing.cs:183)
TryToDoAThing.Start () (at Assets/TryToDoAThing.cs:177)


Output from Rider
=================
	UnityScheduler.Schedule<ValueTuple<int,Action<int,Action<int,TimeSpan>>>>() in , Assembly-CSharp.dll at /Users/shane/unity/rxnet-trial-proj/Assets/UnityScheduler.cs:23:5
	Scheduler.Schedule<int>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Recursive.cs:109:13
	SchedulePeriodicRecursive`1.Start() in , System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Services.Emulation.cs:567:17
	Scheduler.SchedulePeriodic_<ValueTuple<_,Action<_>>>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Services.Emulation.cs:314:17
	Scheduler.SchedulePeriodic<_>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Services.Emulation.cs:79:13
	_.Run() in , System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Linq\Observable\Timer.cs:141:25
	Relative.Run() in , System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Linq\Observable\Timer.cs:100:56
	<>c.<SubscribeRaw>b__1_0() in , System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Internal\Producer.cs:121:30
	<>c__75`1.<ScheduleAction>b__75_0() in , System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Simple.cs:65:21
	CurrentThreadScheduler.Schedule<ValueTuple<Action<ValueTuple<Producer<long,_>,_>>,ValueTuple<Producer<long,_>,_>>>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\CurrentThreadScheduler.cs:101:21
	LocalScheduler.Schedule<ValueTuple<Action<ValueTuple<Producer<long,_>,_>>,ValueTuple<Producer<long,_>,_>>>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\LocalScheduler.cs:32:13
	Scheduler.ScheduleAction<ValueTuple<Producer<long,_>,_>>() in System.Reactive.Concurrency, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Concurrency\Scheduler.Simple.cs:61:13
	Producer`2.SubscribeRaw() in System.Reactive, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Internal\Producer.cs:119:17
	Producer`2.Subscribe() in System.Reactive, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Internal\Producer.cs:97:13
	ObservableExtensions.Subscribe<long>() in System, System.Reactive.dll at D:\a\1\s\Rx.NET\Source\src\System.Reactive\Observable.Extensions.cs:63:13
	TryToDoAThing.Attempt4Works() in , Assembly-CSharp.dll at /Users/shane/unity/rxnet-trial-proj/Assets/TryToDoAThing.cs:57:5
	TryToDoAThing.RunAttempt() in , Assembly-CSharp.dll at /Users/shane/unity/rxnet-trial-proj/Assets/TryToDoAThing.cs:206:9
	TryToDoAThing.RunButton() in , Assembly-CSharp.dll at /Users/shane/unity/rxnet-trial-proj/Assets/TryToDoAThing.cs:183:7
	TryToDoAThing.Start() in , Assembly-CSharp.dll at /Users/shane/unity/rxnet-trial-proj/Assets/TryToDoAThing.cs:177:5
*/
  public static void Case1<T>() {
    GenScheduleAction<(Timer.Periodic.Relative, Timer.Periodic._)>();
  }

}
}
