; Listing generated by Microsoft (R) Optimizing Compiler Version 18.00.30723.0 

include listing.inc

INCLUDELIB LIBCMT
INCLUDELIB OLDNAMES

PUBLIC	main
EXTRN	TEST_setup1:PROC
EXTRN	TEST_search1:PROC
EXTRN	TEST_delete1:PROC
EXTRN	TEST_delete2:PROC
pdata	SEGMENT
$pdata$main DD	imagerel $LN3
	DD	imagerel $LN3+36
	DD	imagerel $unwind$main
pdata	ENDS
xdata	SEGMENT
$unwind$main DD	010401H
	DD	04204H
xdata	ENDS
; Function compile flags: /Odtp
_TEXT	SEGMENT
main	PROC
; File c:\src\blog posts\linked lists\integer linked list runner.c
; Line 3
$LN3:
	sub	rsp, 40					; 00000028H
; Line 4
	call	TEST_setup1
; Line 5
	call	TEST_search1
; Line 6
	call	TEST_delete1
; Line 7
	call	TEST_setup1
; Line 8
	call	TEST_delete2
; Line 9
	xor	eax, eax
; Line 10
	add	rsp, 40					; 00000028H
	ret	0
main	ENDP
_TEXT	ENDS
END
