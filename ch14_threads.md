# The Thread Pool

## 1. Basics:
- Cannot set `Name` of `pooled_thread` but can attach **description** in `VS Threads window`
- `pooled_threads` are always **background** threads.
- Check: `Thread.CurrentThreads.IsThreadPoolthread`

## 2. Entering the thread pool:
- Task.Run(()=>Write("gday"));

## 3. Tasks
Is a promise to do some work:
- can be done via a thread: cpu work
- can be done via external resource: i/o work
- can be?

## 3.1 Tasks

### 99. Misc
`nums = int[1000];`

Where can values be stored:
- registers: for a 64-bit cpu or 8-bytes:
    - int are 4-bytes
    - long are 8-bytes
    - one pointer/reference is 8-bytes
    - can hold a few values
- l1, l2, l3 cache
    - int[1000] = 4 bytes * 1000 = 4,000 bytes
    - lives in ram, but parts can be copied into cache
    - can hold thousands of bytes
- ram
    - gigabytes
- ssd