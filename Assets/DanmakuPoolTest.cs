﻿using DanmakU;
using DanmakU.Fireables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanmakuPoolTest : MonoBehaviour {

  DanmakuPool pool;
  Danmaku danmakuTest;

  public int PoolSize;
  public DanmakuRenderer Renderer;
  public DanmakuState State;
  IFireable fireable;
  float timer;

	void Start () {
    pool = new DanmakuPool(PoolSize);
    fireable = 
      new Ring(5, 0)
        .Of(new Circle(8, 3))
        .Of(new PoolFireable(pool));
    if (Renderer != null) {
      Renderer.Pool = pool;
    }
	}

  /// <summary>
  /// Update is called every frame, if the MonoBehaviour is enabled.
  /// </summary>
  void Update() {
    pool.Update().Dispose();
    timer += Time.deltaTime;
    if (timer > 1/20f) {
      State.Rotation += 20 * Mathf.Deg2Rad;
      fireable.Fire(State);
      timer = 0;
    }
  }

  /// <summary>
  /// This function is called when the MonoBehaviour will be destroyed.
  /// </summary>
  void OnDestroy() => pool.Dispose();

}
