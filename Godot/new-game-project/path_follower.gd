extends AnimatedSprite2D

@onready var _follow :PathFollow2D = get_parent()

signal Traveled

func _ready():
	_follow.progress_ratio = 0
	play("default")
	var duration = 3
	var tween :Tween = create_tween().set_trans(Tween.TRANS_SINE).set_ease(Tween.EASE_IN_OUT)
	tween.tween_property(_follow, 'progress_ratio', 1, duration)
	await get_tree().create_timer(duration + 5).timeout
	Traveled.emit()
