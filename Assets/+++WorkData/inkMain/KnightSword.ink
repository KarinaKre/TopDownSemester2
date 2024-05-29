===KnightSword===

=Start
Sir Knight :Where are thou going?
+[out]
Sir Knight :Without thou sword? Unacceptable, go fetch ye sword.
~ Event("start Sword Quest")
->END

=Run
Sir Knight :...
->END

=Deliver

Sir Knight :Brilliant. You may go now
+[im going now]

Sir Knight : Yes you are
~ Event("Finished Quest")
->END

=Done 
Sir Knight :Off you go
->END

